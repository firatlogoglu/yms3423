NiterProject - Onion Mimari
--------------------------

* Boþ bir solution açýyoruz. Boþ solution içerisine katmanlarýmýzý sýrasýyla tek tek oluþturacaðýz.

-----------------------------------------------------------------------------

*Öncelikle projemize katmanlarýmýzý açýyoruz.
	-NTierProject.Core
	-NTierProject.Model
	-NTierProject.SERVICE
	---------------------------------------------
	-NTierProject.API
	-NTierProject.UI
-------------------------------------------------------------------------

--Core Katmaný

1. NTier.Core is,mli bir C# library açýyoruz.
1.1 Bu kütüphane içerisine Entity, Map, Service, Enum klasörlerini oluþturuyoruz.
1.2 enum klasörü içerisine Statuleri enum olarak tanýmlýyoruz.
1.3 IEntity interface oluþturuyoruz. Ýçerisine Id tanýmlamasý yapýyoruz.
1.4 CoreEntity class oluþturuyoruz. Ortak tüm propertyleri yazýp Constructor tarafýnda ön tanýmlama yapýyoruz.
1.5 Map sýnýfý yazýyoruz ve CoreEntity içerisinde var olan tüm propertylerin mapleme iþlemini "Fluent Api" kullanarak gerçekleþtiriyoruz.
1.6 Service içerisine veritabaný üzerinde gerçekleþtirilecek olan ortak iþlemlerimizi içeren metotlarý ekliyoruz.
------------------------------------------------------------------
------------------------------------------------------------------

--MODEL Katmaný

2.1 NTierProject.MODEL isminde bir class library(.Net Frameowrk) açýyoruz.
2.2 Nuget Package Manager üzerinden EntityFramework yüklüyoruz.
2.3 NTierProject.CORE katmanýndan referans alýyoruz.
2.4 Entities isminde bir klasör oluþturuyoruz. Bu klasörümüz ORM yapýsý için veritabanýnda tablo haline gelecek olan classlarýmýzý barýndýracak. Ýçinde; AppUser, Category, Order, OrderDetail, Product, SubCategory classlarý bulunmaktadýr.
2.5 Map isminde bir klasör tanýmlayýp Entites içerisinde oluþturduðumuz classlarýn veritabanýna hangi kurallar içerisinde gideceðini FluentApi kullanarak gerçekleþtiriyoruz.
2.6 Context isminde bir klasör oluþturup içerisinde ProjectContext isminde bir class açýyoruz. Bu class daha önce oluþturduðumuz yapýlarýmýzý (Entities, Map) toplayýp veritabanýna gönderim iþlemini gerçekleþtirecek.
2.7 Son olarak Package Manager Console'u açarak ilk etapta enable-migrations komutu ile beraber migration'ý aktif hale getirip, Otomatik oluþturulan Configuration.cs classý içerisinde bulunan AutomaticMigrations özelliðine true olarak deðiþtiriyoruz. Ardýndan yine Package Manage Console'a update-database komutunu yazarak veritabanýmýzý oluþturuyoruz.



------------------------------------------------------------------------

--SERVICE Katmaný

3.1 NTierProject.SERVICE, isminde bir class library(.Net Frameowrk) açýyoruz.
3.2 Nuget Package Manager üzerinden EntityFramework yüklüyoruz.
3.3 NTierProject.CORE ve NTierProject.MODEL  katmanlarýndan referans alýyoruz.
3.4 Base isminde bi klasör oluþturuyoruz. Bu klasör daha önce tanýmlanan Core katmaný içerisine BaseService ve Model katmanýndaki Entities içerisinde bulunan classlarýn hangi görevleri üstleneceðini belirliyor.
3.5 Option isminde bir klasör oluþturulur. Bu klasör Az önce tanýmlanan BaseService den miras alarak belirtilen görevleri yine belirtilen classlara aktarýlýr. Örneðin sadece kullanýcýlarý ilgilendiren AppUser isimli class'ýn özel olarak gerçekleþtireceði iþlemler varsa Option içerisindeki AppUserService içerisinde bu kurallar belirtilir.

-------------------------------------------------------------------------

--WebUI Katmaný

4.1 NTierProject.SWebUI, isminde bir class library(.Net Frameowrk) açýyoruz.
4.2 Nuget Package Manager üzerinden EntityFramework yüklüyoruz.
4.3 NTierProject.CORE ve NTierProject.MODEL,NTierProject.SERVICE  katmanlarýndan referans alýyoruz.
4.4 Projemize ilk etap bir Area tanýmlýyoruz. Yönetimsel iþlemleri Admin isimli area içerisinde gerçekleþtireceðimiz için bu yapý dýþarýdaki MVC yapýsýndan farklý olarak tasarlanacak.
4.5 Admin Area içerisinde bulunan View/Shared içerisine dýþtaki MVC den farklý olarak bir tasarým dahil edilir.
4.6 Admin area içerisinde daha önce Service katmanýnda oluþturulan her bir service ait Controller oluþturulur. Bu controller'a Crud iþlemi tanýmlanýr. Örn. Product, Create,Update,Delete
4.7 Dýþta bulunan MVC yapýsý içerisinde bulunan Controllerde Home isimli bir controller oluþturulur ve bu controller siteye ilk istekte bulunan ziyaretçilere gösterilir.




