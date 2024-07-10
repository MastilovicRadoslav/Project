﻿using Common.Entities;
using System.Collections.Generic;
using System.ServiceModel;

namespace Common.Interfaces
{
	[ServiceContract]
	public interface ICommentService
	{
		[OperationContract]
		void AddComment(CommentData comment);
		[OperationContract]
		List<CommentData> GetAllComments();
		[OperationContract]
		CommentData GetComment(int id);

		//[OperationContract]
		//void LikeComment(int id);

		//[OperationContract]
		//void UnlikeComment(int id);

		[OperationContract]
		void UpdateComment(CommentData comment); // Dodato
	}
}