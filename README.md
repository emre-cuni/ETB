# ETB Case

# Bu proje C# .Net ile geliştirilmiş bir Windows Form Uygulamasıdır. Veri tabanı olarak MSSQL kullanılmıştır.

# Projede yapılabilen fonksiyonlar:
* Kullanıcı Kayıt İşlemi
* Kullanıcı Girişi
* Kayıtlı Kullanıcıları Görüntüleme
* Görüntülenen Kullanıcının Bütün Bilgileri Görme

# Projenin Akışı
* Veri tabanında kayıtlı 6 kullanıcı bulunmaktadır.
* İlk girişte "admin@admin.com" mail adresi ve "admin" parolasıyla giriş yapılabiliniyor.
* "admin" parolasıyla giriş yaptıktan sonra otomatik olarak parola yenileme ekranına yönlendiriyor.
* Parola sıfırlandıktan sonra kayıtlı kullanıcılar listeleniyor.
* İstenen kullanıcının üzerine tıklandığında kullanıcının bütün detayları açılan formda görüntüleniyor.
* "Kayıt Ol" sekmesinde kullanıcı bilgileri alınıyor.
* "Kayıt Ol" butonuna tıklandığında girilen mail adresi veri tabanında kayıtlı olup olmadığı kontrol ediliyor.
* Eğer girilen mail adresi kayıtlıysa hata mesajı ekrana bastırılıyor.
* Girilen mail adresi kayıtlı değilse mail adresine "ecom.destek@outlook.com" adresinde bir doğrulama kodu gönderiliyor.
* Doğrulama kodu gönderildikten sonra açılan ekranda gönderilen kod ile girilen kod karşılaştırılıyor.
* Kodlar eşleşirse kullanıcı kaydı yapılıyor ve bilgi mesajı ekrana bastırılıyor.
* Kullanıcı parolası veritabanına şifrelenerek kaydediliyor.
* Şifreleme için 128 bitlik AES şifreleme algoritması kullandım.
* "Giriş Yap" sekmesinde sadece yetkisi olan kullanıcılar giriş yapabiliyor.
* Yetkisi olan kullanıcılar kullanıcı detay ekranında istedikleri kullanıcıya yetki verebiliyorlar.
* Kullanıcı detay ekranında yapılan değişiklik(yetki alma/verme) sonrasında değişikliklerin kaydedilmesi için kullanıcıya seçenek sunuluyor.
* Kullanıcıların fotoğrafları Bin->Debug->Photos dizininde "ad_soyad" şeklinde tutulmaktadır. 
