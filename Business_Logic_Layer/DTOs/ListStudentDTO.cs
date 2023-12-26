using System;
using System.Xml.Serialization;
using Business_Logic_Layer.DTOs;
using Data_Acess_Layer.Entities;

namespace Business_Logic_Layer
{
    [XmlRoot("ListStudent")]
    public class ListStudentDTO
    {
        [XmlElement("Student")]
        public List<StudentDTO> Students { get; set; }
    }
}
