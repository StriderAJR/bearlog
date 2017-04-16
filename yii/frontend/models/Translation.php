<?php
namespace frontend\models;

use yii\db\ActiveRecord;
use yii\web\IdentityInterface;

class Translation extends ActiveRecord 
{
	public static function tableName() {
		return 'translation';
	}
}
