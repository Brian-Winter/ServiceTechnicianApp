﻿using Service.Data;
using Service.Model.MachineModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MachineService
    {

        //Read All
        public IEnumerable<MachineListAll> GetAllMachines()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Machines
                                .Select(
                                    e => new MachineListAll
                                    {
                                        MachineId = e.MachineId,
                                        MachineName = e.MachineName,
                                        SerialNumber = e.SerialNumber,
                                        NumberOfDrawers = e.NumberOfDrawers,
                                        Color = e.Color
                                    }
                                );
                return query.ToArray();
            }
        }
        //Read Single
        public MachineDetail GetMachineById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx
                                .Machines
                                .Single(e => e.MachineId == id);
                return new MachineDetail
                {
                    MachineId = query.MachineId,
                    MachineName = query.MachineName,
                    SerialNumber = query.SerialNumber,
                    NumberOfDrawers = query.NumberOfDrawers,
                    Color = query.Color
                };
                
            }
        }
        //Create
        public bool CreateMachine(MachineCreate model)
        {
            var entity = new Machine()
            {
                SerialNumber = model.SerialNumber,
                MachineName = model.MachineName,
                NumberOfDrawers = model.NumberOfDrawers,
                SpeedPerMinute = model.SpeedPerMinute,
                Color = model.Color,
                Cost = model.Cost,
                

            };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Machines.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Edit
        public bool EditMachine(MachineEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Machines
                                .Single(e => e.MachineId == model.MachineId);

                
                entity.SerialNumber = model.SerialNumber;
                entity.MachineName = model.MachineName;
                entity.NumberOfDrawers = model.NumberOfDrawers;
                entity.SpeedPerMinute = model.SpeedPerMinute;
                entity.Color = model.Color;
                

                return ctx.SaveChanges() == 1;

            }
        }

    }
}
