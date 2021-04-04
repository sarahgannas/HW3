using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAttendance.model
{
    class Attendance
    {
        [DisplayName("Date")]
        public String attandancedate { get; set; }
        [DisplayName("Teacher Name")]
        public Teacher teacher { get; set; }
        [DisplayName("Course Name")]
        public Course course { get; set; }
        [DisplayName("Room/Lab Name")]
        public Room room { get; set; }
        [DisplayName("Start Time")]
        public String starttime { get; set; }
        [DisplayName("Leave Time")]
        public String leavetime { get; set; }
        [DisplayName("Note")]
        public String comment { get; set; }

        public Attendance() {
            this.attandancedate = "";
            this.teacher = null;
            this.course = null;
            this.room = null;
            this.starttime = "";
            this.leavetime = "";
            this.comment = "";
        }
        public Attendance(String attandancedate,Teacher teacher, Course course, Room room, string starttime,
                string leavetime, string comment)
        {

            this.attandancedate = attandancedate;
            this.teacher = teacher;
            this.course = course;
            this.room = room;
            this.starttime = starttime;
            this.leavetime = leavetime;
            this.comment = comment;

        }



    }
}
