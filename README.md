# PetikoyVeterinary
Merhaba, PetikoyVeterinary projesi kullandığım teknolojileri gösterebilmek ve kendimi geliştirmek adına İstanbul-Beşiktaş Wissen Akademi'de eğitim aldığım süreç sonucunda yapmış olduğum bireysel projemdir.
Bazı zamanlar farklı lokasyonlarda yaşayan hayvan sahipleri evcil hayvanlarının sağlıkları konusunda yeterli desteği görememektedir çünkü her işlemi veya ameliyatı her yer yapamayabilir. Bundan dolayı böyle bir proje gerçekleştirmek istedim. Bu proje ile hayvan sahibi şikayetini veterinere iletebilir, soru sorabilir ve mevcut klinik hakkında bilgi alabilir. Admin Paneli ile veteriner Login ve Register işlemlerini gerçekleştirebilir. Contact kısmında hayvan sahibi veteriner ile iletişim kurup şikayetini ifade eder ve hekim gerekli gördüğü tarihte randevu düzenleyip hayvan sahibini bilgilendirebilir. 

Bu projenin şuan ki halini 1.Faz olarak tanımlıyorum. 2.Faz olarak daha fazla geliştirmeyi düşünüyorum.
Projenin tüm hakları ben Kaan Çolak'a aittir. 

Açık kaynak kod yapısını desteklediğim için proje kaynak kodları public olarak yayınlandı. 
### Proje Hakkında Teknik Bilgiler

- Proje .NET C# Aspnet MVC CORE alt yapısıyla yazılmıştır.
- Proje Entity Framework CORE - Code-First yaklaşımıyla yazılmıştır.
- Projenin rol ve kullanıcı yönetimi Aspnet.Identity CORE ile yazılmıştır.
- Projenin FrontEnd işlemlerinde hazır temalar düzenlenerek kullanıldı.
- Projeyi 4 katman (Entities,BL,PL,UI) olarak yazıldı.
- Projede Repository Design Pattern kullanıldı.
- Projede admin paneli de bulunmaktadır ve yeni randevu oluşumu, bütün randevu taleplerinin gösterimi ve oluşmuş ranedvu bilgileri buradan ayarlanabilir.
- Projede ilk olarak ana sayfa bizi karşılamaktadır. Müşteri daha fazla bilgi edinmek isteyebilir veya direk iletişime geçmek isteyebilir. Onun dışında veteriner kendi kullanıcı adı ve şifresiyle bağlanabileceği özel ekranına girebilir. 

Ekran resimleri ise aşağıdaki gibidir.
![anasayfa](https://github.com/kaanxcolak/PetikoyVeterinary/assets/75448807/6d671108-aaad-4595-b4bf-6476495974c0)
![about](https://github.com/kaanxcolak/PetikoyVeterinary/assets/75448807/84aa3ade-a30d-4a91-8848-e6a480b8576b)
![contact](https://github.com/kaanxcolak/PetikoyVeterinary/assets/75448807/4c681222-1856-482a-bafc-b6f6a8d51671)
![login](https://github.com/kaanxcolak/PetikoyVeterinary/assets/75448807/fe9f6fce-d73a-4cec-a637-7234f5a40b2c)
![register](https://github.com/kaanxcolak/PetikoyVeterinary/assets/75448807/60a12438-cbbd-476e-b44a-d825e97e9771)
![createAppointments](https://github.com/kaanxcolak/PetikoyVeterinary/assets/75448807/e73de532-7f51-487b-bba5-8eda385817ab)
![Appointments](https://github.com/kaanxcolak/PetikoyVeterinary/assets/75448807/b8f1640d-21fd-43bd-b9a8-895e24c15c32)
![AllContacts](https://github.com/kaanxcolak/PetikoyVeterinary/assets/75448807/c8dfb575-9180-494b-a913-040d8772c615)
