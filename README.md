# SE-4458-Software-Architecture-Design-of-Modern-Large-Scale-Systems-Midterm-1
# Proje Amacı: 
Projenin amacı mobile app, banking app ve web sitesinin API isteklerini karşılamaktır. Bu proje .net ve entity framework, mysql teknolojileri kullanılarak oluşturulan bir backend projesidir. 
Database: Database kısmında bills, billdetails olmak üzere 2 tablo bulunmaktadır. Bills tablosu bir kullanıcının aylık bazda faturalarını ödeyip ödemediğini ve topalm miktarını gösterir. Billdetails tabloosu ise bir faturanın o ay yaptığı harcamların nerde yapıldığınım ve miktarını gösterir.

# ER Diagram:

 ![Picture1](https://github.com/kubranurcivelek/SE-4458-Software-Architecture-Design-of-Modern-Large-Scale-Systems-Midterm-1/assets/76735018/4588cebd-2156-4cc8-9974-a2c7a2b01dea)

 User tablosu şimdilik static olarak .net projesi içeriisnde bulunmaktadır. İlerleyen süreçte user tablosu olarak eklenecektir.

# Design:
Proje 3 temel parça üzerine kurulmuştur. Bunlar Controller, Entities, DTOlardır.
# •	Controller:
  Controllerlar applicationların ulaştığı api gateleri oluşturur. Controllerda database tabanlı listeleme, güncelleme, oluşturma ve silme gibi işlemler burda   
  gerçekleştirilir. Ayrıca kullanıcının giriş yaparak ulaşabilme yetkilendirilmesi burda yapılmaktadır. Kullanıcının yapmak istediği asıl işlem burada 
  gerçekleştirilir. 
# •	Entities: 
  Context kullanılarak .net kısmındaki entity classları ile databasedeki tabloların eşleştirilmesi sağlanır. 
# •	DTO: 
  Kullanıcının gönderdiği ya da kullanıcıya gösterilen data yapılarıdır. Controllerlarda oluşturulur ve kullanılır.

# Issues and Assumptions: 
•	Month parametresi şimdilik int olarak tanıtılmıştır, tam net tarih tutulmamaktadır. ilerleyen zamanlarda dateTime olarak değiştirilip apilerin de buna benzer şekilde çalıştırılması beklenmektedir. 
•	Kullanıcı test amaçlı static olarak bulunmaktadır. Kullanıcı eklenip çıkarılabilir olacak şekilde databasede tablosu oluşturulup login controller ona göre değiştiirlecektir.
•	Primary keyler int olarak tutulup yüksek data sayısında yetersiz kalmaktadır. Milyarlara ulaşacak datalar için primary keylerin düzenlenmesi gerekmektedir.
•	Kullanıcı rol controlleri şimdilik yoktur. İlerleyen dönemlerde hangi apilerin hangi rollerde çalışacağı belirlenecektir.

