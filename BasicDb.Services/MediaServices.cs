﻿using BasicDb.Data;
using BasicDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicDb.Services
{
    public class MediaService
    {
        private readonly string _userId;
        public MediaService(string userId)
        {
            _userId = userId;
        }
        public MediaService() { }

        //POST
        public bool CreateMedia(MediaCreate media)
        {
            var entity =
                new Media()
                {
                    MediaId = media.MediaId,
                    Title = media.Title,
                    MediaType = media.MediaType,
                    Description = media.Description,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Media.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET
        public IEnumerable<MediaGet> GetMedia()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Media.Select(e => new MediaGet { MediaId = e.MediaId, Title = e.Title, MediaType = e.MediaType, Description = e.Description, AddedBy = e.User.UserName  });
                return query.ToArray();
            }

        }


        public MediaDetail GetMediaById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (ctx.Media.Count(e => e.MediaId == id) > 0)
                {
                    var entity = ctx.Media.Single(e => e.MediaId == id);

                    return new MediaDetail
                    {
                        MediaId = entity.MediaId,
                        Title = entity.Title,
                        MediaType = entity.MediaType,
                        Description = entity.Description,
                        AddedBy = entity.AddedBy,
                    };
                }

                return new MediaDetail();
            }
        }

        //UPDATE
        public string UpdateMedia(MediaUpdate model)

        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Media.Single(e => e.MediaId == model.MediaId && e.AddedBy == _userId);
                entity.MediaId = model.MediaId;
                entity.Title = model.Title;
                entity.MediaType = model.MediaType;
                entity.Description = model.Description;
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        //DELETE
        public bool DeleteMedia(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Media
                        .Single(e => e.MediaId == Id);

                ctx.Media.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
