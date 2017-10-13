using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatingsiteSpice.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;

namespace DatingsiteSpice.Controllers
{
    public class ProfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Profiles
        public ActionResult Index()
        {
            return View(db.Profiles.ToList());
        }

        // GET: Profiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // GET: Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nickname,Gender,Preference,Birthdate,Height,Ethnicity,City,EducationLevel,Interests,Image,PhotoAlbum")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Profiles.Add(profile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(profile);
        }

        // GET: Profiles/Edit/5
        public ActionResult Edit(Profile profile, HttpPostedFileBase imageUpload)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var currentUser = manager.FindById(User.Identity.GetUserId());
            if (currentUser == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            profile = db.Profiles.FirstOrDefault(p=>p.User.Id == currentUser.Id);
            if (profile == null)
            {
                return RedirectToAction("Create");
            }
            return View(profile);

            Profile storedProfile = db.Profiles.Where(p => p.User.Id == currentUser.Id).SingleOrDefault();

            if (storedProfile == null)
            {
                storedProfile = profile;
                profile.User = currentUser;
                db.Profiles.Add(storedProfile);
            }

            storedProfile.Birthdate = profile.Birthdate;
            storedProfile.City = profile.City;
            storedProfile.EducationLevel = profile.EducationLevel;
            storedProfile.Ethnicity = profile.Ethnicity;
            storedProfile.Gender = profile.Gender;
            storedProfile.Preference = profile.Preference;
            storedProfile.Height = profile.Height;
            storedProfile.Nickname = profile.Nickname;

            if (imageUpload != null && imageUpload.ContentLength > 0)
            {  // create directory
                var uploadPath = Path.Combine(Server.MapPath("~/Content/Uploads"), storedProfile.ID.ToString());
                Directory.CreateDirectory(uploadPath);

                // create filename
                string fileGuid = Guid.NewGuid().ToString();
                string extension = Path.GetExtension(imageUpload.FileName);
                string newFilename = fileGuid + extension;

                // copy file
                imageUpload.SaveAs(Path.Combine(uploadPath, newFilename));

                // store in database
                Picture pic = new Picture { Filename = newFilename };
                storedProfile.Image = pic;
                db.Pictures.Add(pic);
            }
            
            db.SaveChanges();

            return View(storedProfile);
        }

        // POST: Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nickname,Gender,Preference,Birthdate,Height,Ethnicity,City,EducationLevel,Interests,Image,PhotoAlbum")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        // GET: Profiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile profile = db.Profiles.Find(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        // POST: Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profile profile = db.Profiles.Find(id);
            db.Profiles.Remove(profile);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
