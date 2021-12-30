using Entity.Concrete;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string AddressAdded = "Adres eklendi";
        public static string AddressDeleted = "Adres silindi";
        public static string AddressUpdated = "Adres güncellendi";
        public static string BasketAdded = "Sepete eklendi";
        public static string BasketDeleted = "Sepetten  silindi";
        public static string BasketUpdated = "Sepet güncellendi";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string CategoryAdded = "Kategori eklendi";
        public static string CategoryDeleted = "Kategori silindi";
        public static string CategoryUpdated = "Kategori güncellendi";
        public static string CityAdded = "Şehir eklendi";
        public static string CityDeleted = "Şehir silindi";
        public static string CityUpdated = "Şehir güncellendi";
        public static string ProductImageAdded = "Ürün resmi eklendi";
        public static string ProductImageDeleted = "Ürün resmi silindi";
        public static string ProductImageUpdated="Ürün resmi güncellendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string ProductCountOfCategoryError = "Bir kategorideki ürün sayısı aşıldı";
        public static string ProductNameAlreadyExists = "Aynı isimli ürün mevcuttur";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        public static string UserNameAlreadyExists = "Kullanıcı ismi zaten kayıtlı";
        public static string BrandNameAlreadyExists = "Marka kayıtlı";
        public static string AddressAlreadyExists = "Adres zaten kayıtlı";
        public static string ProductImageCountError = "Ürün resim sayısı hatası";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string PasswordError = "Parola hatası";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string AccessTokenCreated = "Kullanıcı mevcut";
    }
}
 