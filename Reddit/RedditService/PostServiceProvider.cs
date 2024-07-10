﻿using Common.Entities;
using Common.Interfaces;
using Common.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RedditService
{
	public class PostServiceProvider : IPostService
	{
		private readonly static PostRepository repository = new PostRepository();

		public void AddPost(PostData post)
		{
			repository.Create(new PostData(post.Title) { Id = post.Id, Title = post.Title, Description = post.Description, Image = post.Image, UserEmail = post.UserEmail, Like = post.Like, UnLike = post.UnLike });
		}

		public List<PostData> GetAllPosts()
		{
			return repository
				  .ReadAll()
				  .Select(post => new PostData
				  {
					  Id = post.Id,
					  Title = post.Title,
					  Description = post.Description,
					  Image = post.Image,
					  UserEmail = post.UserEmail,
					  Like = post.Like,
					  UnLike = post.UnLike
				  }).ToList();
		}

		public PostData GetPost(int id)
		{
			PostData post = repository.Read(id);
			return post;
		}

		public bool RemovePost(int id)
		{
			return repository.Delete(id);
		}

		//public void LikePost(int id)
		//{
		//	PostData post = repository.Read(id);
		//	if (post != null)
		//	{
		//		post.Like++;
		//		repository.Update(post);
		//	}
		//}

		//public void UnlikePost(int id)
		//{
		//	PostData post = repository.Read(id);
		//	if (post != null)
		//	{
		//		post.UnLike++;
		//		repository.Update(post);
		//	}
		//}

		public void UpdatePost(PostData post) // Dodato: Nova metoda za ažuriranje postova
		{
			repository.Update(post);
		}
	}
}