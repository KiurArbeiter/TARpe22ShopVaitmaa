﻿using Microsoft.AspNetCore.Mvc;
using TARpe22ShopVaitmaa.Core.Domain.Spaceship;
using TARpe22ShopVaitmaa.Core.Dto;
using TARpe22ShopVaitmaa.Core.ServiceInterface;
using TARpe22ShopVaitmaa.Data;
using TARpe22ShopVaitmaa.Models.Spaceship;

namespace TARpe22ShopVaitmaa.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly TARpe22ShopVaitmaaContext _context;
        private readonly ISpaceshipsServices _spaceshipsServices;
        public SpaceshipsController
            (
                TARpe22ShopVaitmaaContext context,
                ISpaceshipsServices spaceshipsServices
            ) 
        { 
            _context = context; 
            _spaceshipsServices = spaceshipsServices;
        }
        public IActionResult Index()
        {
            var result = _context.Spaceships
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new SpaceshipIndexViewModel { 
                    Id = x.Id, 
                    Name = x.Name, 
                    Type = x.Type, 
                    PassengerCount = x.PassengerCount, 
                    EnginePower = x.EnginePower });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            SpaceshipCreateUpdateViewModel spaceship = new SpaceshipCreateUpdateViewModel();
            return View("CreateUpdate", spaceship);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Price = vm.Price,
                Type = vm.Type,
                Name = vm.Name,
                Description = vm.Description,
                FuelType = vm.FuelType,
                FuelCapacity = vm.FuelCapacity,
                FuelConsumption = vm.FuelConsumption,
                PassengerCount = vm.PassengerCount,
                EnginePower = vm.EnginePower,
                DoesHaveAutopilot = vm.DoesHaveAutopilot,
                CrewCount = vm.CrewCount,
                CargoWeight = vm.CargoWeight,
                DoesHaveLifeSupportSystems = vm.DoesHaveLifeSupportSystems,
                BuiltDate = vm.BuiltDate,
                LastMaintenance = vm.LastMaintenance,
                MaintenanceCount = vm.MaintenanceCount,
                FullTripsCount = vm.FullTripsCount,
                MaidenLaunch = vm.MaidenLaunch,
                Manufacturer = vm.Manufacturer,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
            };
            var result = await _spaceshipsServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var spaceship = await _spaceshipsServices.GetAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipCreateUpdateViewModel()
            {

                Id = spaceship.Id,
                Price = spaceship.Price,
                Type = spaceship.Type,
                Name = spaceship.Name,
                Description = spaceship.Description,
                FuelType = spaceship.FuelType,
                FuelCapacity = spaceship.FuelCapacity,
                FuelConsumption = spaceship.FuelConsumption,
                PassengerCount = spaceship.PassengerCount,
                EnginePower = spaceship.EnginePower,
                DoesHaveAutopilot = spaceship.DoesHaveAutopilot,
                CrewCount = spaceship.CrewCount,
                CargoWeight = spaceship.CargoWeight,
                DoesHaveLifeSupportSystems = spaceship.DoesHaveLifeSupportSystems,
                BuiltDate = spaceship.BuiltDate,
                LastMaintenance = spaceship.LastMaintenance,
                MaintenanceCount = spaceship.MaintenanceCount,
                FullTripsCount = spaceship.FullTripsCount,
                MaidenLaunch = spaceship.MaidenLaunch,
                Manufacturer = spaceship.Manufacturer,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt,
            };

            return View("CreateUpdate",vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Price = vm.Price,
                Type = vm.Type,
                Name = vm.Name,
                Description = vm.Description,
                FuelType = vm.FuelType,
                FuelCapacity = vm.FuelCapacity,
                FuelConsumption = vm.FuelConsumption,
                PassengerCount = vm.PassengerCount,
                EnginePower = vm.EnginePower,
                DoesHaveAutopilot = vm.DoesHaveAutopilot,
                CrewCount = vm.CrewCount,
                CargoWeight = vm.CargoWeight,
                DoesHaveLifeSupportSystems = vm.DoesHaveLifeSupportSystems,
                BuiltDate = vm.BuiltDate,
                LastMaintenance = vm.LastMaintenance,
                MaintenanceCount = vm.MaintenanceCount,
                FullTripsCount = vm.FullTripsCount,
                MaidenLaunch = vm.MaidenLaunch,
                Manufacturer = vm.Manufacturer,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
            };
            var result = await _spaceshipsServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {

            var spaceship = await _spaceshipsServices.GetAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipDetailsViewModel()
            {

                Id = spaceship.Id,
                Price = spaceship.Price,
                Type = spaceship.Type,
                Name = spaceship.Name,
                Description = spaceship.Description,
                FuelType = spaceship.FuelType,
                FuelCapacity = spaceship.FuelCapacity,
                FuelConsumption = spaceship.FuelConsumption,
                PassengerCount = spaceship.PassengerCount,
                EnginePower = spaceship.EnginePower,
                DoesHaveAutopilot = spaceship.DoesHaveAutopilot,
                CrewCount = spaceship.CrewCount,
                CargoWeight = spaceship.CargoWeight,
                DoesHaveLifeSupportSystems = spaceship.DoesHaveLifeSupportSystems,
                BuiltDate = spaceship.BuiltDate,
                LastMaintenance = spaceship.LastMaintenance,
                MaintenanceCount = spaceship.MaintenanceCount,
                FullTripsCount = spaceship.FullTripsCount,
                MaidenLaunch = spaceship.MaidenLaunch,
                Manufacturer = spaceship.Manufacturer,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt,
            };

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {

            var spaceship = await _spaceshipsServices.GetAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipDeleteViewModel()
            {

                Id = spaceship.Id,
                Price = spaceship.Price,
                Type = spaceship.Type,
                Name = spaceship.Name,
                Description = spaceship.Description,
                FuelType = spaceship.FuelType,
                FuelCapacity = spaceship.FuelCapacity,
                FuelConsumption = spaceship.FuelConsumption,
                PassengerCount = spaceship.PassengerCount,
                EnginePower = spaceship.EnginePower,
                DoesHaveAutopilot = spaceship.DoesHaveAutopilot,
                CrewCount = spaceship.CrewCount,
                CargoWeight = spaceship.CargoWeight,
                DoesHaveLifeSupportSystems = spaceship.DoesHaveLifeSupportSystems,
                BuiltDate = spaceship.BuiltDate,
                LastMaintenance = spaceship.LastMaintenance,
                MaintenanceCount = spaceship.MaintenanceCount,
                FullTripsCount = spaceship.FullTripsCount,
                MaidenLaunch = spaceship.MaidenLaunch,
                Manufacturer = spaceship.Manufacturer,
                CreatedAt = spaceship.CreatedAt,
                ModifiedAt = spaceship.ModifiedAt,
            };

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var spaceshipId = await _spaceshipsServices.Delete(id);
            if (spaceshipId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
