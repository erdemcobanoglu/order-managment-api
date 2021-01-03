## Ne Kullandım ?

- C#
- .Net Core Api
- EntityFramework Core
- Code First
- Repository Pattern
- Unit Of Work Pattern 
- Dependency Injection
- Newtonsoft Json 
- Swagger 
- Git-Github
- MsSql

## Verileri Kaydetme

- Json dosyası içerisindeki verileri veritabanına kaydetmek için uygun bir model oluşturup.
- EntityFramework yardımı ve Code first yaklaşımı ile MsSql üzerinden veritabanımı oluşturdum.

## Repository, Unit Of Work Pattern Uygulama

- Veritabanına kayıt attıktan sonra sıra bu kayıtlar ve veritabanı üzerinden işlem yapmaya geldi. 
- Projenin daha da genişleyebileceğini göz önüne ve veritabanına yapılcak işlemleri tek bir sınıftan yönetmek için alarak Generic Repository ve Unit Of Work sınıflarını kullandım. 

## Api Oluşturma

- Dışarıdan veritabanında değişiklik yapabilmesi için .Net Core Api kullandım. Bu apinin işlem yapabilmesi için servislerin interfacelerini constructordan enjecte ettim. 
- Service sınıflarıma da GenericRepository interfacelerini enjecte ettim. 
- Dependency injection yönetimini .Net Core da default olarak bulunan container ile yöneterek Swagger yardımı ile api controller'ları test ettim.

## Versiyon Yönetimi

- Projeyi sizinde alıp inceleyebilmeniz için git altyapısını kullanan github sitesine yükledim. Projeye  https://github.com/erdemcobanoglu/order-managment-api linkinden ulaşabilirsiniz.

## Faydalandığım Kaynaklar

- https://github.com/ 
- https://stackoverflow.com/
- https://www.restapitutorial.com/lessons/restfulresourcenaming.html/