using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.DTOs
{
    public record AuthorDTO
    (string Name, string Bio, string ImgURL);

    public record UpdateAuthorDTO
    (string Name, string Bio, string ImgURL,int id);
}
