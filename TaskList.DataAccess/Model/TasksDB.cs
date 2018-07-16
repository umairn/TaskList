using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskList.DataAccess
{
    [Table("Tasks")]
    public class TasksDB {
            /// <summary>
            /// 
            /// </summary>
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key, Column(Order = 0)]
            public int Id { get; set; }

            public Guid TaskId { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [StringLength(50)]
            [Column(Order = 1)]
             public string TaskName { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [StringLength(200)]
            [Column(Order = 2)]
            public string TaskDescription { get; set; }
            /// <summary>
            /// 
            /// </summary>
            /// 
            [Column(Order = 3)]
            public bool IsComplete { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [StringLength(50)]
            [Column(Order = 4)]
            public string Owner { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [Column(Order = 6)]
            public DateTime Created_at { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [Column(Order = 7)]
            public DateTime Updated_at { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [StringLength(50)]
            [Column(Order = 8)]
            public string Created_by { get; set; }
            /// <summary>
            /// 
            /// </summary>
            [StringLength(50)]
            [Column(Order = 9)]
            public string Updated_by { get; set; }

        }
    }

