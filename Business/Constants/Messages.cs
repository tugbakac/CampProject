using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static bool ProductsListed;
        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        public static string ProductNameAlreadyExist = "Aynı isimde ürün eklenemez.";
        public static string CategoryLimitExceded = "Kategori sayısı 15 olduğu için ürün eklenemedi.";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string UserAlreadyExists = "Kullanıcı kayıtlı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Hatalı Parola";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string AccessTokenCreated = "Token Oluşturuldu";
    }
}
