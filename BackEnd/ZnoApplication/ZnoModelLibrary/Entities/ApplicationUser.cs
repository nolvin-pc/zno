using Microsoft.AspNetCore.Identity;

namespace ZnoModelLibrary.Entities
{
    /// <summary>
    ///  Модель "пользователь"
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Статус (в сети, не в сети, в тестировании)
        /// </summary>
        public Status Status { get; set; }
        /// <summary>
        /// Полное имя пользователя
        /// </summary>
        public string FullName { get; set; }
    }
}