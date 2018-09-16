using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilters();
            PhotoProcessor.PhotoFilterHnadler filterHnadler = filters.ApplyBrightness;
            filterHnadler += filters.ApplyContrast;
            filterHnadler += filters.RemoveRedEyeFilter;
            processor.Process("photo.jpg", filterHnadler);
        }
    }

    public class Photo
    {
        public static Photo Load(string path)
        {
            return new Photo();
        }

        public void Save()
        {
            Console.WriteLine("photo is saved");
        }
    }

    public class PhotoProcessor
    {
        public delegate void PhotoFilterHnadler(Photo photo);

        public void Process(string path, PhotoFilterHnadler filterHnadler)
        {
            var photo = Photo.Load(path);

            filterHnadler(photo);

            photo.Save();
        }
    }

    public class PhotoFilters
    {
        public void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("brightness is applied");
        }
        public void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Contrast is applied");
        }
        public void Resize(Photo photo)
        {
            Console.WriteLine("photo is resized");
        }
        public void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Red eye is remove");
        }
    }
}
