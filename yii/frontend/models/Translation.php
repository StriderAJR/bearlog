<?php
namespace frontend\models;

use yii\db\ActiveRecord;
use yii\web\IdentityInterface;
use frontend\models\TranslationBook;

class Translation extends ActiveRecord 
{
	public static function tableName() {
		return 'translation';
	}

	public static function getUserTranslations($userID)
	{
		$translations = [];
		$translations['books'] = TranslationBook::find()
							->select(['book_id', 'translation.cover_link', 'translation.name'])
							->join('JOIN', 'translation', 'book.translation_id = translation.translation_id')
							->where("translation.creator_id='{$userID}'")
							->asArray()
							->all();

		// $translations['images'] = [];
		// $translations['subtitles'] = [];

		return $translations;		
	}
}
