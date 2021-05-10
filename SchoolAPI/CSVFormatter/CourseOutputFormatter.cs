using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace SchoolAPI.CSVFormatter
{
    public class CourseOutputFormatter : TextOutputFormatter
    {
        public CourseOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        protected override bool CanWriteType(Type type)
        {
            if (typeof(CourseDto).IsAssignableFrom(type) ||
            typeof(IEnumerable<CourseDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext
       context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();
            if (context.Object is IEnumerable<CourseDto>)
            {
                foreach (var course in (IEnumerable<CourseDto>)context.Object)
                {
                    FormatCsv(buffer, course);
                }
            }
            else
            {
                FormatCsv(buffer, (CourseDto)context.Object);
            }
            await response.WriteAsync(buffer.ToString());
        }
        private static void FormatCsv(StringBuilder buffer, CourseDto course)
        {
            buffer.AppendLine($"{course.Id},\"{course.CourseName}");
        }
    }

}
