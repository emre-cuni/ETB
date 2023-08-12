using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace etb
{
    internal class Encryption
    {
        private byte[] key = { 0x73, 0x69, 0x6d, 0x70, 0x6c, 0x65, 0x65, 0x6e, 0x63, 0x72, 0x79, 0x70, 0x74, 0x69, 0x6f, 0x6e }; // şifreleme anahtarı
        private byte[] iv = { 0x73, 0x69, 0x6d, 0x70, 0x6c, 0x65, 0x65, 0x6e, 0x63, 0x72, 0x79, 0x70, 0x74, 0x69, 0x6f, 0x6e }; // başlatma vektörü

        public string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msEncrypt = new MemoryStream()) // Şifrelenmiş veriyi saklamak için memorystream nesnesi oluşturur
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) // CryptoStream oluşturur ve şifreler
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText); // Veriyi şifreleyerek streamwriter nesnesine yazar
                        }
                    }

                    // IV ve şifrelenmiş veriyi birleştirerek byte dizisi oluştur
                    byte[] encryptedByte = new byte[aesAlg.IV.Length + msEncrypt.ToArray().Length];
                    Array.Copy(aesAlg.IV, encryptedByte, aesAlg.IV.Length);
                    Array.Copy(msEncrypt.ToArray(), 0, encryptedByte, aesAlg.IV.Length, msEncrypt.ToArray().Length);

                    return Convert.ToString(encryptedByte); // Byte dizisini string'e çevirir ve döndürür
                }
            }
        }

        public string Decrypt(string encryptedText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                byte[] ivAndEncrypted = Convert.FromBase64String(encryptedText);
                byte[] encrypted = new byte[ivAndEncrypted.Length - iv.Length];

                Array.Copy(ivAndEncrypted, iv, iv.Length);
                Array.Copy(ivAndEncrypted, iv.Length, encrypted, 0, encrypted.Length);

                aesAlg.Key = key;
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(encrypted)) // Şifrelenmiş veriyi memorystream nesnesine yükler
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) // CryptoStream oluşturur ve çözer
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd(); // Çözülen veriyi okur ve döndürür
                        }
                    }
                }
            }
        }
    }
}
