using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeacherAttendance.helper;
using TeacherAttendance.model;

namespace TeacherAttendance
{
    public partial class frmTeacherAttendance : Form
    {
        private AttendanceManagement attendance;
        private BindingSource bindingSource = new BindingSource();
        public frmTeacherAttendance()
        {
            InitializeComponent();
        }

        private void FrmTeacherAttendance_Load(object sender, EventArgs e)
        {
            attendance = new AttendanceManagement();
            ShowCourses();
            ShowTeachers();
            ShowRooms();

            //bindingSource.Add();
            DGVAttendance.DataSource = new List<Attendance>() { new Attendance() };
            DGVAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        
        private void ShowCourses()
        {
            cmbCourses.DataSource = null;
            cmbCourses.DisplayMember = "CourseName";
            cmbCourses.ValueMember = "CourseId";
            cmbCourses.DataSource = attendance.getAllCourses();
            cmbCourses.SelectedIndex = -1;
        }

        private void ShowTeachers()
        {
            cmbTeacherName.DataSource = null;
            cmbTeacherName.DisplayMember = "TeacherName";
            cmbTeacherName.ValueMember = "TeacherId";
            cmbTeacherName.DataSource = attendance.getAllTeachers();
            cmbTeacherName.SelectedIndex = -1;

        }

        private void ShowRooms()
        {
            cmbRoom.DataSource = null;
            cmbRoom.DisplayMember = "RoomName";
            cmbRoom.ValueMember = "RoomId";
            cmbRoom.DataSource = attendance.getAllRooms();
            cmbRoom.SelectedIndex = -1;

        }
        private void CmbCourses_SelectionChangeCommitted(object sender, EventArgs e)
        {
            

            string value = "";
            

            int id = ((Course)((ComboBox)sender).SelectedItem).CourseId;

            if(id != 0)
            {
                return;
            }

            if (Prompt.InputBox("New course", "New course name:", ref value) == DialogResult.OK)
            {
                if (value.Trim().Length > 0)
                {
                    attendance.addNewCourse(value.Trim());
                    ShowCourses();
                }


            }
        }

        private void CmbTeacherName_SelectionChangeCommitted(object sender, EventArgs e)
        {


            string value = "";


            int id = ((Teacher)((ComboBox)sender).SelectedItem).TeacherId;

            if (id != 0)
            {
                return;
            }

            if (Prompt.InputBox("New teacher", "New teacher name:", ref value) == DialogResult.OK)
            {
                if (value.Trim().Length > 0)
                {
                    attendance.addNewTeacher(value.Trim());
                    ShowTeachers();
                }


            }


        }

        private void CmbRoom_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string value = "";


            int id = ((Room)((ComboBox)sender).SelectedItem).RoomId;

            if (id != 0)
            {
                return;
            }

            if (Prompt.InputBox("New Room/Lab", "New Room/Lab name:", ref value) == DialogResult.OK)
            {
                if (value.Trim().Length > 0)
                {
                    attendance.addNewRoom(value.Trim());
                    ShowRooms();
                }


            }

        }

        private void BtnSave_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            
            DGVAttendance.DataSource = null;
            attendance.addAttendance(DTPickerdate.Value.ToString(), 
                                    (Teacher) cmbTeacherName.SelectedItem,
                                    (Course) cmbCourses.SelectedItem, 
                                    (Room) cmbRoom.SelectedItem, 
                                    DTPickerStartTime.Value.ToString(), 
                                    DTPickerLeaveTime.Value.ToString(), txtComment.Text);

            bindingSource.DataSource = attendance.getAllAttendance();
            DGVAttendance.DataSource = bindingSource;

            cln();
        }

        private void DGVAttendance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // عند الضغط على الداتا جرد فيو عند خلية معينة يقوم بتعبئة القيمة في الادات الخاصة بالقيمة
            // قمنا ايضا بتغير حالة زر التعديل الى السماحية بالاستخدام
            button1.Enabled = true;
            // هنا قمنا بتعبئة قيمة المتغير اندكس و هو متغير معرف على مستوى الفورم استخدمناه في التعديل


            // هنا قمنا بتحديد في اي سطر قام بالضغط المستخدم
            index = DGVAttendance.CurrentRow.Index;

            // هنا في حالة كان الضغط على العمود رقم 1 و هو عامود الاستاذ
            if (e.ColumnIndex == 1)
            {
                Attendance currentAtt = attendance.getAttendanceByIndex(e.RowIndex);

             //   MessageBox.Show(((Teacher) currentAtt.teacher).TeacherId + "");
                cmbTeacherName.SelectedValue= ((Teacher)currentAtt.teacher).TeacherId;

                // هنا في حالة كان الضغط على العمود رقم 2 و هو عامود الصفوف
            }
            else if (e.ColumnIndex == 2)
            {
                Attendance currentAtt = attendance.getAttendanceByIndex(e.RowIndex);

                cmbCourses.SelectedValue = ((Course)currentAtt.course).CourseId;
            }


            // هنا في حالة كان الضغط على العمود رقم 3 و هو عامود الغرف

            else if (e.ColumnIndex == 3)
            {

                Attendance currentAtt = attendance.getAttendanceByIndex(e.RowIndex);

                cmbRoom.SelectedValue = ((Room)currentAtt.room).RoomId;
            }
        }

        private void DGVAttendance_DoubleClick(object sender, EventArgs e)
        {
            // عند الضغط على الداتا جرد فيو مرتين يقوم بتعبئة القيمة في الادوات
            // قمنا ايضا بتغير حالة زر التعديل الى السماحية بالاستخدام
            button1.Enabled = true;
              Attendance currentAtt = attendance.getAttendanceByIndex(
                DGVAttendance.CurrentRow.Index
            );
            // هنا قمنا بتعبئة قيمة المتغير اندكس و هو متغير معرف على مستوى الفورم استخدمناه في التعديل
            index = DGVAttendance.CurrentRow.Index;
           DateTime dt = DateTime.Parse(currentAtt.attandancedate);
            DTPickerdate.Value = dt;

            //MessageBox.Show(currentAtt.teacher.TeacherName);
            cmbTeacherName.Text = currentAtt.teacher.TeacherName;

            cmbCourses.Text = currentAtt.course.CourseName;

            cmbRoom.Text = currentAtt.room.RoomName;


            txtComment.Text = currentAtt.comment;


        }
        int index;
        void cln()
        {
            cmbTeacherName.SelectedIndex = -1;
            cmbCourses.SelectedIndex = -1;
            cmbRoom.SelectedIndex = -1;
            txtComment.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // لتنظيف الداتا جرد فيو
            DGVAttendance.DataSource = null;
            // قمنا بعمل اجراء في الكلاس مانجمنت لتعديل 
            // لتعديل نحتاج كل القيم بالاضافة الى الاندكس لتحديد في اي صف سنعدل
            // index عبينا القيمة متاعه من الحدث سيل كلك و  الحدث دبل كلك لداتا جرد فيو
            attendance.editAttendance( DTPickerdate.Value.ToString(),
                                    (Teacher)cmbTeacherName.SelectedItem,
                                    (Course)cmbCourses.SelectedItem,
                                    (Room)cmbRoom.SelectedItem,
                                    DTPickerStartTime.Value.ToString(),
                                    DTPickerLeaveTime.Value.ToString(), txtComment.Text, index);
            // اجراء التعديل غير سطر الليست الذي اردنا تعديله بالقيم المعدلة ثم اعدنا ملئ الداتا جرد فيو
            bindingSource.DataSource = attendance.getAllAttendance();
            DGVAttendance.DataSource = bindingSource;
            // بعد التعديل قمنا بتغير خاصية الانبل لزر التعديل الى فلس 
            button1.Enabled = false;
            cln();
        }
    }
}
