using System.ComponentModel.DataAnnotations;

namespace Js_Tree.Models
{
    public class Tree
    {
        [Required]
        [Key]
        public string Id { get; set; }
        [Required]
        public string Parent {  get; set; }
        [Required]
        public string Text { get; set; }

    }
}
