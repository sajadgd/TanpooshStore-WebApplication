using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanpooshStore.Application.Interfaces;
using TanpooshStore.Application.Services.Products.UploadFiles;
using TanpooshStore.Common.Dto;
using TanpooshStore.Domain.Entities.HomePages;

namespace TanpooshStore.Application.Services.HomePages.AddNewSlider
{
    public class AddnewSliderService : IAddNewSliderService
    {
        private readonly IDatabaseContext _context;
        private readonly IHostingEnvironment _environment;
        public AddnewSliderService(IDatabaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public ResultDto Execute(IFormFile file, string link)
        {
            try
            {
                var uploadResult = UploadFile(file);

                var slider = new SliderEntity
                {
                    Link = link,
                    Src = uploadResult.FileNameAddress,
                    InsertTime = DateTime.Now,
                };
                _context.Tbl_Slider.Add(slider);
                _context.SaveChanges();

                var result = new ResultDto
                {
                    IsSuccess = true,
                    Message = "تصویر مورد نظر به اسلایدر اضافه شد !"
                };
                return result;
            }
            catch
            {
                var result1 = new ResultDto
                {
                    IsSuccess = false,
                    Message = "در عملیات مورد نظر خطایی پیش آمد !"
                };
                return result1;
            }
        }

        private UploadFileDto UploadFile(IFormFile file)
        {
            if (file != null)
            {
                string folder = $@"images/HomePageImages/Slider/";
                var uploadsRootFolder = Path.Combine(_environment.WebRootPath, folder);
                if (!Directory.Exists(uploadsRootFolder))
                {
                    Directory.CreateDirectory(uploadsRootFolder);
                }

                string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
                var filePath = Path.Combine(uploadsRootFolder, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                var result = new UploadFileDto
                {
                    Status = true,
                    FileNameAddress = folder + fileName
                };
                return result;
            }
            else
            {
                var result1 = new UploadFileDto
                {
                    Status = false,
                    FileNameAddress = ""
                };
                return result1;
            }
        }
    }
}
