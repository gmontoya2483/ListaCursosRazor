using ListaCursos.Interfaces;
using ListaCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaCursos.Providers
{
    public class FakeCoursesProvider : ICoursesProvider
    {

        private readonly List<Course> repo = new List<Course>();

        public FakeCoursesProvider()
        {
            repo.Add(new Course() {
            Id = 1,
            Name = "Arquitectura de software: Patrones esencial",
            Author= "Carlos Solís",
            Description= "Descubre el potencial de los patrones de diseño para crear sistemas de software. Este contenido te mostrará los principales patrones de diseño utilizados en la creación de software y cómo usarlos para crear sistemas sólidos, con buenas prácticas y usando soluciones probadas en la industria. Paso a paso, te introducirás en las bases conceptuales de los patrones de diseño de arquitectura y entenderás cómo funcionan, cómo solventar los problemas comunes al incorporarlos y, finalmente, cómo encontrar el patrón perfecto.",
            Uri = "https://www.linkedin.com/learning/arquitectura-de-software-patrones-esencial/por-que-usar-patrones-de-diseno-en-arquitectura-de-software?u=91286938"
            });

            repo.Add(new Course()
            {
                Id = 2,
                Name = "Prepara tu curriculum vitae",
                Author = "Lorena Díaz Quijano",
                Description = "Desarrolla un curriculum vitae ganador que te permita captar la atención de los especialistas en recursos humanos. En este contenido formativo aprenderás a preparar tu currículum para que sea útil, eficaz y atractivo durante el proceso de selección. Descubrirás qué información debes incluir, la importancia de contar con un buen diseño o estructura visual o cómo desarrollar perfiles destacables en la web, redes sociales y espacios digitales, entre otros conceptos clave. El puesto de tus sueños te está esperando y está a un currículo de distancia.",
                Uri = "https://www.linkedin.com/learning/prepara-tu-curriculum-vitae-2/como-preparar-tu-curriculum-vitae?u=91286938"
            });

            repo.Add(new Course()
            {
                Id = 3,
                Name = "Búsqueda de empleo con redes sociales",
                Author = "Lorena Díaz Quijano",
                Description = "Desarrolla un curriculum vitae ganador que te permita captar la atención de los especialistas en recursos humanos. En este contenido formativo aprenderás a preparar tu currículum para que sea útil, eficaz y atractivo durante el proceso de selección. Descubrirás qué información debes incluir, la importancia de contar con un buen diseño o estructura visual o cómo desarrollar perfiles destacables en la web, redes sociales y espacios digitales, entre otros conceptos clave. El puesto de tus sueños te está esperando y está a un currículo de distancia.",
                Uri = "https://www.linkedin.com/learning/busqueda-de-empleo-con-redes-sociales/busqueda-de-empleo-con-redes-sociales?u=91286938"
            });
        }

        public Task<(bool IsSuccess, int? Id)> AddAsync(Course course)
        {
            course.Id = repo.Max(c => c.Id) + 1;
            repo.Add(course);

            return Task.FromResult((true, (int?)course.Id));

        }

        public Task<ICollection<Course>> GetAllAsync()
        {
            return Task.FromResult((ICollection<Course>)repo.ToList());
        }

        public Task<Course> GetAsync(int id)
        {
            return Task.FromResult(repo.FirstOrDefault(c => c.Id == id));
        }

        public Task<ICollection<Course>> SearchAsync(string search)
        {
            return Task.FromResult((ICollection<Course>)repo.Where(c => c.Name.ToLowerInvariant().Contains(search.ToLowerInvariant())).ToList());
        }

        public Task<bool> UpdateAsync(int id, Course course)
        {
            var courseToUpdate = repo.FirstOrDefault(c => c.Id == id);
            if (courseToUpdate != null) 
            {
                courseToUpdate.Name = course.Name;
                courseToUpdate.Description = course.Description;
                courseToUpdate.Author = course.Author;
                course.Uri = course.Uri;

                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }




    }
}
