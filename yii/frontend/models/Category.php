<?php
namespace frontend\models;

use yii\db\ActiveRecord;
use yii\web\IdentityInterface;

class Category extends ActiveRecord 
{
	public static function tableName() {
		return 'category';
	}
}
