﻿using AspNetCoreProjeKampı.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreProjeKampı.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetWriterById(int id)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == id);
            var jsonWriters = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriters);
        }

        [HttpPost]
        public IActionResult AddWriter(WriterClass writer)
        {
            writers.Add(writer);
            var jsonWriters = JsonConvert.SerializeObject(writer);
            return Json(jsonWriters);
        }

        public IActionResult UpdateWriter(WriterClass writer)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writer.Id);
            findWriter.Name = writer.Name;
            var jsonWriter = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriter);
        }

        public IActionResult DeleteWriter(int id)
        {
            var writer = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(writer);
            return Json(writer);
        }

        public IActionResult WriterList()
        {
            var jsonWriters = JsonConvert.SerializeObject(writers);
            return Json(jsonWriters);
        }

        public static List<WriterClass> writers = new List<WriterClass>
        {
            new WriterClass
            {
                Id=1,
                Name="Ömer"
            },
            new WriterClass
            {
                Id =2,
                Name ="Ahmet"
            },
            new WriterClass
            {
                Id =3,
                Name ="Buse"
            }
        };
    }
}
