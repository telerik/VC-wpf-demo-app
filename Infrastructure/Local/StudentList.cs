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
    public class StudentList : ObservableCollection<Student>
    {
        public StudentList() : base()
        {
            this.CollectionChanged += StudentList_CollectionChanged;
            this.LoadData();
        }

        private void LoadData()
        {
            if (File.Exists("students.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<Student>));
                using (var file = File.OpenRead("students.xml"))
                {
                    var savedData = (List<Student>)serializer.Deserialize(file);

                    foreach (var student in savedData)
                    {
                        Add(student);
                    }
                }
            }
            else
            {
                Add(new Student { Id = 1, Name = "Peter Lucas", Email = "peter.lucas@mail.com", Course = "First", Specialty = "Computer Science" });
                Add(new Student { Id = 2, Name = "Martha Golding", Email = "m.golding@mail.com", Course = "Second", Specialty = "Computer Science" });
                Add(new Student { Id = 3, Name = "Sandra Butler", Email = "s.butler@mail.com", Course = "First", Specialty = "Networking" });
                Add(new Student { Id = 4, Name = "Robert Balentine", Email = "robert.b@mail.com", Course = "Third", Specialty = "Electronics" });
                Add(new Student { Id = 5, Name = "Joseph Spicer", Email = "j.spicer@mail.com", Course = "Second", Specialty = "Networking" });
                Add(new Student { Id = 6, Name = "Linda Sam", Email = "sam.linda@mail.com", Course = "Fourth", Specialty = "Networking" });
                Add(new Student { Id = 7, Name = "Delia Smith", Email = "ddelia@mail.com", Course = "Second", Specialty = "Electronics" });
                Add(new Student { Id = 8, Name = "Shannon Glass", Email = "shan.glass@mail.com", Course = "Third", Specialty = "Computer Science" });
                Add(new Student { Id = 9, Name = "George Griffin", Email = "griffinn@mail.com", Course = "First", Specialty = "Computer Science" });
                Add(new Student { Id = 10, Name = "Keith Neimann", Email = "k.neimann@mail.com", Course = "Second", Specialty = "Computer Science" });
                Add(new Student { Id = 11, Name = "Kim Thomas", Email = "k.tommas@mail.com", Course = "Fourth", Specialty = "Electronics" });
                Add(new Student { Id = 12, Name = "Jared Hilton", Email = "hiltonn@mail.com", Course = "Third", Specialty = "Electronics" });
                Add(new Student { Id = 13, Name = "Brandy Hunt", Email = "hunt.brandy@mail.com", Course = "Second", Specialty = "Networking" });
                Add(new Student { Id = 14, Name = "David Cox", Email = "d.coxx@mail.com", Course = "First", Specialty = "Computer Science" });
                Add(new Student { Id = 15, Name = "Martha Mejia", Email = "mmejia@mail.com", Course = "Third", Specialty = "Computer Science" });
                Add(new Student { Id = 16, Name = "Andrew Maez", Email = "a.maezz@mail.com", Course = "Fourth", Specialty = "Networking" });
                Add(new Student { Id = 17, Name = "Connie Williams", Email = "c.williams@mail.com", Course = "First", Specialty = "Computer Science" });
                Add(new Student { Id = 18, Name = "Brett Miller", Email = "bredd.mil@mail.com", Course = "Third", Specialty = "Electronics" });
                Add(new Student { Id = 19, Name = "Kevin Vargas", Email = "kev.vargas@mail.com", Course = "Second", Specialty = "Networking" });
                Add(new Student { Id = 20, Name = "Joseph Garmon", Email = "joseph.s.garmon@mail.com", Course = "Fourth", Specialty = "Computer Science" });
            }
        }

        private void StudentList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Student item in e.OldItems)
                {
                    item.PropertyChanged -= Item_PropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Student item in e.NewItems)
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
            var serializer = new XmlSerializer(typeof(List<Student>));
            using (var file = new FileStream("students.xml", FileMode.Create))
            {
                serializer.Serialize(file, new List<Student>(this));
            }
        }
    }
}
