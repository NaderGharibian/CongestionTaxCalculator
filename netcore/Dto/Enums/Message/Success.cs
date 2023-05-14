using System.ComponentModel.DataAnnotations;

namespace Dto.Enums.Message
{
    public enum Success
    {
        [Display(Name = "Welcome")]
        WELCOME = 0, 
        
        [Display(Name = "Successfully completed")]
        SUCCESSFULLY_COMPLETED = 1,

    }
}
