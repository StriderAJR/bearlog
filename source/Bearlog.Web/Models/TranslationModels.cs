using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bearlog.Web.Models
{
    public class TranslationModel
    {
        public Guid Id { get; set; }

    }

    public class BookModel : TranslationModel
    {
        public string AuthorName { get; set; }
        public string AuthorOriginalName { get; set; }
        public int Year { get; set; }
        public List<Chapter> Fragments { get; set; }

    }

    public class Chapter
    {
        public Guid Id { get; set; }
        public List<Fragment> Fragments { get; set; }
    }

    public class Fragment
    {
        public Guid Id { get; set; }
        public List<FragmentTranslation> Translations { get; set; }


    }

    public class FragmentTranslation{
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public Guid FragmentId { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime CreateAt { get; set; }


    }
}