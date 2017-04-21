<?php
namespace frontend\models;

use yii\db\ActiveRecord;
use yii\web\IdentityInterface;

class TranslationPart extends ActiveRecord 
{
	public static function tableName() {
		return 'tranlsation_part';
	}
}
