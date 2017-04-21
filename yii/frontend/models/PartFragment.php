<?php
namespace frontend\models;

use yii\db\ActiveRecord;
use yii\web\IdentityInterface;

class PartFragment extends ActiveRecord 
{
	public static function tableName() {
		return 'part_fragment';
	}
}
