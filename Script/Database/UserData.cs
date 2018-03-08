﻿using UnityEngine;

/// <summary>
/// ユーザーデータ保存処理クラス
/// </summary>
public static class UserData
{

	// 保存キー
	private static readonly string KEY_DATABASE_VERSION = "DATABASE_VERSION";

	// 初期値
	private static readonly int DEF_DATABASE_VERSION = 0;
	
	/// <summary>
	/// データベースのバージョン
	/// </summary>
	public static int DatabaseVersion
	{
		get
		{
			return PlayerPrefs.GetInt(KEY_DATABASE_VERSION, DEF_DATABASE_VERSION);
		}
		set
		{
			PlayerPrefs.SetInt(KEY_DATABASE_VERSION, value);
		}
	}

	/// <summary>
	/// データを保存する
	/// </summary>
	public static void Save()
	{
		PlayerPrefs.Save();
	}


}