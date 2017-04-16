<?php
namespace frontend\models;

use yii\db\ActiveRecord;
use yii\web\IdentityInterface;
use frontend\models\Translation;

class TranslationBook extends Translation 
{
	public static function tableName() {
		return 'book';
	}
}
