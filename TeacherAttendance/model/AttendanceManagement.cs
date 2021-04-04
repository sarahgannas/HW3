﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeacherAttendance.model
{
    class AttendanceManagement
    {
        private  List<Course> courses;
        private List<Teacher> teachers;
        private List<Room> rooms;
        private List<Attendance> attendance;

        public AttendanceManagement()
        {
            courses = new List<Course>();
            teachers = new List<Teacher>();
            rooms = new List<Room>();
            attendance = new List<Attendance>();
        }

        public void addNewCourse(String CoursName)
        {
            courses.Add(new Course(courses.Count + 1, CoursName));
        }

        public List<Course> getAllCourses()
        {
            List<Course> temp;

            temp = courses.GetRange(0, courses.Count);

            temp.Add(new Course(0, "Add new course..."));

            return temp;

        }

        public void addNewTeacher(String TeacherName)
        {
            teachers.Add(new Teacher(teachers.Count + 1, TeacherName));
        }

        public List<Teacher> getAllTeachers()
        {
            List<Teacher> temp;

            temp = teachers.GetRange(0, teachers.Count);

            temp.Add(new Teacher(0, "Add new teacher..."));

            return temp;

        }

        public void addTeacher(String TeacherName)
        {
            teachers.Add(new Teacher(teachers.Count + 1, TeacherName));
        }


        public void addNewRoom(String RoomName)
        {
            rooms.Add(new Room(rooms.Count + 1, RoomName));
        }

        public List<Room> getAllRooms()
        {
            List<Room> temp;

            temp = rooms.GetRange(0, rooms.Count);

            temp.Add(new Room(0, "Add new room/lab..."));

            return temp;

        }

        public void addAttendance(
                 String attandancedate,Teacher teacher, 
                 Course course, Room room, string starttime,
                 string leavetime, string comment
        )
        {
            

            attendance.Add(new Attendance(attandancedate,teacher, course,room,
            starttime,leavetime,comment));


        }

        public List<Attendance> getAllAttendance()
        {

            return attendance;
        }

        public Attendance getAttendanceByIndex(int index)
        {

            return attendance[index];
        }


        public void editAttendance(
              String attandancedate, Teacher teacher,
              Course course, Room room, string starttime,
              string leavetime, string comment,int index
     )
        {


            attendance[index]=(new Attendance(attandancedate, teacher, course, room,
            starttime, leavetime, comment));


        }



    }





}
