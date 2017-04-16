<?php
namespace frontend\models;

use yii\db\ActiveRecord;
use yii\web\IdentityInterface;

class Language extends ActiveRecord 
{
	public static function tableName() {
		return 'language';
	}
}
