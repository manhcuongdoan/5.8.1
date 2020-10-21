﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Metech.SimpleTaskApp.People
{
    [Table("StsPeople")]
    public class Person : Entity
    {
        public virtual string Name { get; set; }
    }
}
