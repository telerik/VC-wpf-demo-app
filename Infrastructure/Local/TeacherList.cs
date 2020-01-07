using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Xml.Serialization;

namespace Infrastructure.Local
{
    [Serializable]
    public class TeacherList : ObservableCollection<Teacher>
    {
        public TeacherList() : base()
        {
            this.CollectionChanged += TeacherList_CollectionChanged;
            this.LoadData();
        }

        private void LoadData()
        {
            if (File.Exists("teachers.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Student>));
                using (var file = File.OpenRead("teachers.xml"))
                {
                    var savedData = (List<Teacher>)serializer.Deserialize(file);

                    foreach (var teacher in savedData)
                    {
                        Add(teacher);
                    }
                }
            }
            else
            {
                Add(new Teacher { Id = 1, Name = "Alfredo Nesson", Email = "a.nesson@mail.com", Rank = "Professor" });
                Add(new Teacher { Id = 2, Name = "Donald Cannady", Email = "donald.cannady@mail.com", Rank = "Lecturer" });
                Add(new Teacher { Id = 3, Name = "Portia Anderson", Email = "p.anderson@mail.com", Rank = "Assistant Professor" });
                Add(new Teacher { Id = 4, Name = "Sonja Alongi", Email = "sonja.alongi@mail.com", Rank = "Associate Professor" });
                Add(new Teacher { Id = 5, Name = "Irene Atkinson", Email = "ir.atkinson@mail.com", Rank = "Visiting Professor" });
            }
        }

        private void TeacherList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Teacher item in e.OldItems)
                {
                    item.PropertyChanged -= Item_PropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Teacher item in e.NewItems)
                {
                    item.PropertyChanged += Item_PropertyChanged;
                }
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.CreateXml();
        }

        private void CreateXml()
        {
            var serializer = new XmlSerializer(typeof(StudentList));
            using (var file = new FileStream("teachers.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(file, this);
            }
        }
    }
}
