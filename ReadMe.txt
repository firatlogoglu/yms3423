NiterProject - Onion Mimari
--------------------------

* Bo� bir solution a��yoruz. Bo� solution i�erisine katmanlar�m�z� s�ras�yla tek tek olu�turaca��z.

-----------------------------------------------------------------------------

*�ncelikle projemize katmanlar�m�z� a��yoruz.
	-NTierProject.Core
	-NTierProject.Model
	-NTierProject.SERVICE
	---------------------------------------------
	-NTierProject.API
	-NTierProject.UI
-------------------------------------------------------------------------

--Core Katman�

1. NTier.Core is,mli bir C# library a��yoruz.
1.1 Bu k�t�phane i�erisine Entity, Map, Service, Enum klas�rlerini olu�turuyoruz.
1.2 enum klas�r� i�erisine Statuleri enum olarak tan�ml�yoruz.
1.3 IEntity interface olu�turuyoruz. ��erisine Id tan�mlamas� yap�yoruz.
1.4 CoreEntity class olu�turuyoruz. Ortak t�m propertyleri yaz�p Constructor taraf�nda �n tan�mlama yap�yoruz.
1.5 Map s�n�f� yaz�yoruz ve CoreEntity i�erisinde var olan t�m propertylerin mapleme i�lemini "Fluent Api" kullanarak ger�ekle�tiriyoruz.
1.6 Service i�erisine veritaban� �zerinde ger�ekle�tirilecek olan ortak i�lemlerimizi i�eren metotlar� ekliyoruz.
------------------------------------------------------------------
------------------------------------------------------------------

--MODEL Katman�

2.1 NTierProject.MODEL isminde bir class library(.Net Frameowrk) a��yoruz.
2.2 Nuget Package Manager �zerinden EntityFramework y�kl�yoruz.
2.3 NTierProject.CORE katman�ndan referans al�yoruz.
2.4 Entities isminde bir klas�r olu�turuyoruz. Bu klas�r�m�z ORM yap�s� i�in veritaban�nda tablo haline gelecek olan classlar�m�z� bar�nd�racak. ��inde; AppUser, Category, Order, OrderDetail, Product, SubCategory classlar� bulunmaktad�r.
2.5 Map isminde bir klas�r tan�mlay�p Entites i�erisinde olu�turdu�umuz classlar�n veritaban�na hangi kurallar i�erisinde gidece�ini FluentApi kullanarak ger�ekle�tiriyoruz.
2.6 Context isminde bir klas�r olu�turup i�erisinde ProjectContext isminde bir class a��yoruz. Bu class daha �nce olu�turdu�umuz yap�lar�m�z� (Entities, Map) toplay�p veritaban�na g�nderim i�lemini ger�ekle�tirecek.
2.7 Son olarak Package Manager Console'u a�arak ilk etapta enable-migrations komutu ile beraber migration'� aktif hale getirip, Otomatik olu�turulan Configuration.cs class� i�erisinde bulunan AutomaticMigrations �zelli�ine true olarak de�i�tiriyoruz. Ard�ndan yine Package Manage Console'a update-database komutunu yazarak veritaban�m�z� olu�turuyoruz.



------------------------------------------------------------------------

--SERVICE Katman�

3.1 NTierProject.SERVICE, isminde bir class library(.Net Frameowrk) a��yoruz.
3.2 Nuget Package Manager �zerinden EntityFramework y�kl�yoruz.
3.3 NTierProject.CORE ve NTierProject.MODEL  katmanlar�ndan referans al�yoruz.
3.4 Base isminde bi klas�r olu�turuyoruz. Bu klas�r daha �nce tan�mlanan Core katman� i�erisine BaseService ve Model katman�ndaki Entities i�erisinde bulunan classlar�n hangi g�revleri �stlenece�ini belirliyor.
3.5 Option isminde bir klas�r olu�turulur. Bu klas�r Az �nce tan�mlanan BaseService den miras alarak belirtilen g�revleri yine belirtilen classlara aktar�l�r. �rne�in sadece kullan�c�lar� ilgilendiren AppUser isimli class'�n �zel olarak ger�ekle�tirece�i i�lemler varsa Option i�erisindeki AppUserService i�erisinde bu kurallar belirtilir.

-------------------------------------------------------------------------

--WebUI Katman�

4.1 NTierProject.SWebUI, isminde bir class library(.Net Frameowrk) a��yoruz.
4.2 Nuget Package Manager �zerinden EntityFramework y�kl�yoruz.
4.3 NTierProject.CORE ve NTierProject.MODEL,NTierProject.SERVICE  katmanlar�ndan referans al�yoruz.
4.4 Projemize ilk etap bir Area tan�ml�yoruz. Y�netimsel i�lemleri Admin isimli area i�erisinde ger�ekle�tirece�imiz i�in bu yap� d��ar�daki MVC yap�s�ndan farkl� olarak tasarlanacak.
4.5 Admin Area i�erisinde bulunan View/Shared i�erisine d��taki MVC den farkl� olarak bir tasar�m dahil edilir.
4.6 Admin area i�erisinde daha �nce Service katman�nda olu�turulan her bir service ait Controller olu�turulur. Bu controller'a Crud i�lemi tan�mlan�r. �rn. Product, Create,Update,Delete
4.7 D��ta bulunan MVC yap�s� i�erisinde bulunan Controllerde Home isimli bir controller olu�turulur ve bu controller siteye ilk istekte bulunan ziyaret�ilere g�sterilir.




