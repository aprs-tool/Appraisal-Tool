using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APRST.WEB.Models
{
    public class QuestionnaireCategoryViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Название категории")]
        public string NameOfCategory { get; set; }
        [Display(Name = "Описание")]
        public string Desc { get; set; }
    }
}