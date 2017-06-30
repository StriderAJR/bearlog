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
        public List<Part> Fragments { get; set; }

    }

   

    public class Part
    {
        public Guid Id { get; set; }
        public List<PartFragment> PartFragments { get; set; }
        public string Name;
        public string OriginalName { get; set; }

    }

    public class PartFragment
    {
        public Guid Id { get; set; }
        public string OriginalText;
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
        public List<Comments> Comments { get; set; }

    }

    public class Comments
    {
        
    }
}