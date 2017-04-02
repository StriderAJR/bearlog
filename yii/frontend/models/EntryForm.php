<?php

namespace app\models;

use yii\base\Model;

class EntryForm extends Model
{
    public $name;
    public $password;
    public $email;

    public function rules()
    {
        return [
            [['name','password', 'email'], 'required'],
            ['email', 'email'],
        ];
    }
echo $form->field($model, 'email')->input('email');
echo $form->field($model, 'password')->passwordInput();

}