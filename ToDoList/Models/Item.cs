using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Models
{
    [Table("Items")]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public override bool Equals(System.Object otherItem)
        {
            if (!(otherItem is Item))
            {
                return false;
            }
            else
            {
                Item newItem = (Item)otherItem;
                return this.Description.Equals(newItem.Description);
            }
        }

        public override int GetHashCode()
        {
            return this.Description.GetHashCode();
        }
    }
}
