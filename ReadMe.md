## NiterProject - Onion Mimari


* Boş bir solution açıyoruz. Boş solution içerisine katmanlarımızı sırasıyla tek tek oluşturacağız.
* Öncelikle projemize katmanlarımızı açıyoruz.

  ### 1.NTierProject.Core

  ### 2.NTierProject.Model

  ### 3.NTierProject.SERVICE
  

  ### 4.NTierProject.API

  ### 5.NTierProject.UI

-------------------------------------------------------------------------

### Core Katmanı

1. NTier.Core is,mli bir C# library açıyoruz.

1.1 Bu kütüphane içerisine Entity, Map, Service, Enum klasörlerini oluşturuyoruz.

1.2 enum klasörü içerisine Statuleri enum olarak tanımlıyoruz.

1.3 IEntity interface oluşturuyoruz. İçerisine Id tanımlaması yapıyoruz.

1.4 CoreEntity class oluşturuyoruz. Ortak tüm propertyleri yazıp Constructor tarafında ön tanımlama yapıyoruz.

1.5 Map sınıfı yazıyoruz ve CoreEntity içerisinde var olan tüm propertylerin mapleme işlemini "Fluent Api" kullanarak gerçekleştiriyoruz.

1.6 Service içerisine veritabanı üzerinde gerçekleştirilecek olan ortak işlemlerimizi içeren metotları ekliyoruz.

------------------------------------------------------------------

### MODEL Katmanı

2.1 NTierProject.MODEL isminde bir class library(.Net Frameowrk) açıyoruz.

2.2 Nuget Package Manager üzerinden EntityFramework yüklüyoruz.

2.3 NTierProject.CORE katmanından referans alıyoruz.

2.4 Entities isminde bir klasör oluşturuyoruz. Bu klasörümüz ORM yapısı için veritabanında tablo haline gelecek olan classlarımızı barındıracak. İçinde; AppUser, Category, Order, OrderDetail, Product, SubCategory classları bulunmaktadır.

2.5 Map isminde bir klasör tanımlayıp Entites içerisinde oluşturduğumuz classların veritabanına hangi kurallar içerisinde gideceğini FluentApi kullanarak gerçekleştiriyoruz.

2.6 Context isminde bir klasör oluşturup içerisinde ProjectContext isminde bir class açıyoruz. Bu class daha önce oluşturduğumuz yapılarımızı (Entities, Map) toplayıp veritabanına gönderim işlemini gerçekleştirecek.

2.7 Son olarak Package Manager Console'u açarak ilk etapta enable-migrations komutu ile beraber migration'ı aktif hale getirip, Otomatik oluşturulan Configuration.cs classı içerisinde bulunan AutomaticMigrations özelliğine true olarak değiştiriyoruz. Ardından yine Package Manage Console'a update-database komutunu yazarak veritabanımızı oluşturuyoruz.

------------------------------------------------------------------------

### SERVICE Katmanı

3.1 NTierProject.SERVICE, isminde bir class library(.Net Frameowrk) açıyoruz.

3.2 Nuget Package Manager üzerinden EntityFramework yüklüyoruz.

3.3 NTierProject.CORE ve NTierProject.MODEL  katmanlarından referans alıyoruz.

3.4 Base isminde bi klasör oluşturuyoruz. Bu klasör daha önce tanımlanan Core katmanı içerisine BaseService ve Model katmanındaki Entities içerisinde bulunan classların hangi görevleri üstleneceğini belirliyor.

3.5 Option isminde bir klasör oluşturulur. Bu klasör Az önce tanımlanan BaseService den miras alarak belirtilen görevleri yine belirtilen classlara aktarılır. Örneğin sadece kullanıcıları ilgilendiren AppUser isimli class'ın özel olarak gerçekleştireceği işlemler varsa Option içerisindeki AppUserService içerisinde bu kurallar belirtilir.

-------------------------------------------------------------------------

## WebUI Katmanı

4.1 NTierProject.WebUI, isminde bir class library(.Net Frameowrk) açıyoruz.

4.2 Nuget Package Manager üzerinden EntityFramework yüklüyoruz.

4.3 NTierProject.CORE ve NTierProject.MODEL,NTierProject.SERVICE  katmanlarından referans alıyoruz.

4.4 Projemize ilk etap bir Area tanımlıyoruz. Yönetimsel işlemleri Admin isimli area içerisinde gerçekleştireceğimiz için bu yapı dışarıdaki MVC yapısından farklı olarak tasarlanacak.

4.5 Admin Area içerisinde bulunan View/Shared içerisine dıştaki MVC den farklı olarak bir tasarım dahil edilir.

4.6 Admin area içerisinde daha önce Service katmanında oluşturulan her bir service ait Controller oluşturulur. Bu controller'a Crud işlemi tanımlanır. Örn. Product, Create, Update, Delete

4.7 Dışta bulunan MVC yapısı içerisinde bulunan Controllerde Home isimli bir controller oluşturulur ve bu controller siteye ilk istekte bulunan ziyaretçilere gösterilir.




