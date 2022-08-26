using System.ComponentModel.DataAnnotations;
using Laboratorio01.Helpers;

namespace Laboratorio01.Models
{
    public class ClientModel
    {
 
        [Required]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public static bool SaveAVLMode(ClientModel data)
        {
            Data.Instance.miArbolAvlId.Insert(data);
            
            return true;
        }
    }
}

