﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class MealPlan
    {
        public int Id { get; set; }
        public DateTime MealDate { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }

    }
}
