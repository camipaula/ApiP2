﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Progreso1_1.Models;
using Proyecto_Progreso1_1.NewFolder;

namespace Proyecto_Progreso1_1.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IServices _Services;

        // GET: ColorProductoController
        private readonly IServices _apiService;

        public UsuarioController(IServices apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> login(string usuario, string contrasena)
        {
            Usuario usuario1 = await _apiService.GetUsuario(usuario, contrasena);
            if (usuario1 == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }



        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            List<Usuario> usuarios = await _apiService.GetAllUsuarios();
            return View("Index", usuarios);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int IdMarca)
        {
            Marca tipo2 = await _apiService.GetMarca(IdMarca);
            if (tipo2 != null)
            {
                return View(tipo2);
            }
            else
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public async Task<IActionResult> Create()
        {
            // Obtener la lista de categorias
            List<Marca> marcas = await _apiService.GetAllMarcas();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuarioo)
        {
            Usuario tipo1 = await _apiService.CreateUsuario(usuarioo);
            return RedirectToAction("Index");
        }



        // GET: ProductoController/Edit/5
        public async Task<IActionResult> Edit(int idUsuario)
        {
            Usuario tipo = await _apiService.GetUsuario(idUsuario);
            if (tipo != null)
            {
                return View(tipo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Usuario usuarioo)
        {

            Console.WriteLine(usuarioo.usuario.ToString());
            Usuario tipo2 = await _apiService.GetUsuario(usuarioo.idUsuario);
            if (tipo2 != null)
            {
                Usuario tipo3 = await _apiService.UpdateUsuario(usuarioo.idUsuario, usuarioo);

                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idUsuario)
        {
            _apiService.DeleteUsuario(idUsuario);

            return RedirectToAction("Index");


        }

    }
}