using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace ValidationTypesInDotnet8
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }

        [Range(18,60,MinimumIsExclusive =true,MaximumIsExclusive =true)] // allow 19-59
        public int Age { get; set; }

        [Length(1,3)] // allow length 1 to 3
        public ICollection<User> Users { get; set; }    = Array.Empty<User>();


        [AllowedValues("USD","EUR","GBP")]
        public string Currencies { get; set; }

        [DeniedValues("POUND","RUBBLE","BTC")]
        public string DeniedCurrencies { get; set; }

        [Base64String]
        public string Message { get; set; }

    }
}
