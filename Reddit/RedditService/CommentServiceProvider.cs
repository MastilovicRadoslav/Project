using Common.Entities;
using Common.Interfaces;
using Common.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RedditService
{
	public class CommentServiceProvider : ICommentService
	{
		private readonly static CommentRepository repository = new CommentRepository();

		public void AddComment(CommentData comment)
		{
			repository.Create(new CommentData(comment.Text) { Id = comment.Id, Text = comment.Text, PostId = comment.PostId, UserEmail = comment.UserEmail, Like = comment.Like, Unlike = comment.Unlike });
		}

		public List<CommentData> GetAllComments()
		{
			return repository
				  .ReadAll()
				  .Select(comment => new CommentData
				  {
					  Id = comment.Id,
					  Text = comment.Text,
					  PostId = comment.PostId,
					  UserEmail = comment.UserEmail,
					  Like = comment.Like,
					  Unlike = comment.Unlike
				  }).ToList();
		}

		public CommentData GetComment(int id)
		{
			CommentData comment = repository.Read(id);
			return comment;
		}

		//public void LikeComment(int id)
		//{
		//	CommentData comment = repository.Read(id);
		//	if (comment != null)
		//	{
		//		comment.Like++;
		//		repository.Update(comment);
		//	}
		//}

		//public void UnlikeComment(int id)
		//{
		//	CommentData comment = repository.Read(id);
		//	if (comment != null)
		//	{
		//		comment.Unlike++;
		//		repository.Update(comment);
		//	}
		//}
		public void UpdateComment(CommentData comment) // Dodato: Nova metoda za ažuriranje komentara
		{
			repository.Update(comment);
		}
	}
}
