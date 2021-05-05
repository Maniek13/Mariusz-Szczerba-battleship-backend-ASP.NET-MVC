using System;
using System.ComponentModel.DataAnnotations;

namespace Battleships.Models
{
    public class Advertisment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

    }
}
