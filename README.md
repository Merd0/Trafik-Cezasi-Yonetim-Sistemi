# 🚗 Trafik Cezası Yönetim Sistemi 👮

Bu proje, sürücülere kesilen trafik cezalarının kolayca yönetilmesini ve takip edilmesini sağlayan basit bir Windows Forms uygulamasıdır. Hem polis memurlarının yeni cezaları sisteme eklemesi hem de vatandaşların kendi cezalarını sorgulaması için tasarlandı.

---

## 🎯 Proje Amacı

Sistemin temel hedefleri şunlar:

* **Ceza İşleme:** Yeni trafik cezalarını hızlıca sisteme kaydetme. 📝
* **Ödeme Takibi:** Cezaların ödeme durumlarını (ödendi/ödendi) kolayca izleme. 💰
* **Sorgulama:** Vatandaşların kimlik veya plaka numaralarıyla cezalarını görüntülemesi. 🔍
* **Raporlama:** Kayıtlı cezaların genel durumuna dair basit bir bakış sunma. 📊

---

## 💻 Kullanılan Teknolojiler

Bu proje, aşağıdaki temel teknolojilerle geliştirildi:

* **C#:** Uygulamanın kalbi olan programlama dili. ❤️
* **Windows Forms (WinForms):** Kullanıcı arayüzünü (UI) oluşturmak için kullanılan framework. 🖼️

---

## 🚀 Nesne Yönelimli Programlama (OOP) Yaklaşımı

Projemiz, temiz ve genişletilebilir bir yapıya sahip olmak için temel OOP prensiplerini uyguluyor:

* **Kalıtım (Inheritance):** Bütün ceza türleri (`HizCezasi`, `ParkCezasi`, `KirmiziIsikCezasi`) ortak özelliklerini **`Ceza`** adındaki soyut (abstract) temel sınıftan miras alır. Bu sayede kod tekrarını önleriz ve yeni ceza türleri eklemek çok kolaylaşır. 🌳
* **Arayüz (Interface):** **`IOdenecek`** arayüzü, ceza tutarının hesaplanması gibi ödeme ile ilgili ortak davranışları tanımlar. Tüm ceza sınıfları bu arayüzü uygulayarak esneklik sağlar. 🤝
* **Soyutlama (Abstraction):** **`Ceza`** sınıfı, ceza türlerinin ortak ancak spesifik olmayan özelliklerini belirlerken, her alt sınıfın kendine özgü uygulamasını gerektiren metotları soyut bırakır. 👻
* **Kapsülleme (Encapsulation):** Sınıfların iç detayları (örneğin, `GlobalData` sınıfındaki ceza listesi) doğrudan erişime kapatılarak verilere kontrollü erişim sağlanır. 🔒

---

## ✨ Modüller ve Özellikler

Uygulamanın ana kısımları ve yapabildikleri:

* **Ana Ekran (`Form1`):** Polis paneline veya ceza sorgulama ekranına geçiş noktası.
* **Polis Paneli (`polisPanel`):** Basit bir **kullanıcı adı (`polis`)** ve **şifre (`123`)** ile güvenli giriş. Başarılı giriş sonrası ceza ekleme formuna erişim. 🔐
* **Ceza Ekleme Formu (`cezaEkleForm`):** Sürücü bilgileri (ad, soyad, plaka, kimlik no) ve çeşitli ceza türlerini (Kırmızı Işık, Hız, Park İhlali) seçme imkanı. Seçilen cezalara göre **otomatik toplam tutar hesaplama**. Tüm verilerin `GlobalData` listesine eklenmesi. ✅
* **Ceza Sorgulama Formu (`cezaSorgulamaForm`):** *(Henüz detaylandırılmamış olsa da projenin parçası olarak düşünülen bir bölüm.)* Vatandaşların kendi ceza geçmişlerini kimlik veya plaka ile sorgulayabilmesi. ❓
* **Global Veri Yönetimi (`GlobalData` sınıfı):** Uygulama genelindeki tüm cezaların tutulduğu merkezi bir liste. Bütün formlar aynı ceza verisine ulaşabilir. 🌍

---

## ⚙️ Kurulum ve Çalıştırma

Projeyi kendi bilgisayarınızda çalıştırmak için izlemeniz gereken adımlar:

1.  **Depoyu Klonlayın:**
    ```bash
    git clone [https://github.com/Merd0/Trafik-Cezasi-Yonetim-Sistemi.git](https://github.com/Merd0/Trafik-Cezasi-Yonetim-Sistemi.git)
    ```
2.  **Visual Studio ile Açın:**
    * Projenin `.sln` uzantılı dosyasını bulup çift tıklayarak Visual Studio'da açın.
3.  **Derleyin ve Çalıştırın:**
    * Visual Studio'da "Derle" (Build) menüsünden "Çözümü Derle" (Build Solution) seçeneğini seçin.
    * `F5` tuşuna basarak veya "Hata Ayıklama" (Debug) menüsünden "Hata Ayıklamayı Başlat" (Start Debugging) seçeneğiyle uygulamayı çalıştırın. ▶️

---

## 💡 Ek Bilgiler ve Geliştirme İpuçları

* **Kalıcı Veri Depolama:** Şu anki versiyon, uygulama her kapatıldığında verileri kaybeder. Verilerinizi kaydetmek için bir veritabanı (SQL Server, SQLite gibi) veya dosya tabanlı (XML, JSON) bir çözüm entegre edebilirsiniz. 💾
* **LINQ Kullanımı:** `GlobalData.Cezalar` listesi üzerinde **LINQ** (Language Integrated Query) kullanarak ödenmemiş cezaları filtreleme, belirli bir plakaya ait cezaları bulma gibi gelişmiş sorgular yapabilirsiniz. Örneğin:
    ```csharp
    var odenmemisCezalar = GlobalData.Cezalar.Where(c => !c.OdendiMi).ToList();
    ```
* **Hata Yönetimi:** Kullanıcı girişlerindeki hataları (sayı alanına metin girilmesi gibi) daha sağlam bir şekilde ele almak için `try-catch` blokları kullanmayı düşünebilirsiniz. 🚫
* **Gelişmiş Raporlama:** Cezaların ödeme durumu, ceza türüne göre dağılımı gibi daha detaylı ve görsel raporlar oluşturulabilir. 📈

---

## 🤝 Katkıda Bulunma

Projeye katkıda bulunmak isterseniz, çok sevinirim! 😊 Lütfen aşağıdaki adımları izleyin:

1.  Bu depoyu **forklayın** (kendi hesabınıza kopyalayın).
2.  Yeni bir özellik veya hata düzeltmesi için bir **dal oluşturun**: (`git checkout -b feature/HarikaOzellik`).
3.  Değişikliklerinizi **commit edin**: (`git commit -m 'Harika bir özellik eklendi'`).
4.  Dalınızı **push edin**: (`git push origin feature/HarikaOzellik`).
5.  Bir **Pull Request (Çekme İsteği) açın**. 🚀

---

## ⚖️ Lisans

Bu proje **MIT Lisansı** altında lisanslanmıştır. Daha fazla bilgi için lütfen `LICENSE` dosyasına göz atın.

---
