<?php
namespace frontend\modules\home\models;

use yii\base\Model;
use common\models\User;

class LoginForm extends Model
{
    public $email;
    public $password;


    public function rules()
    {
        return [
            ['email', 'filter', 'filter' => 'trim'],
            ['email', 'required', 'message' => 'Это поле не может быть пустым.'],
            ['email', 'email', 'message' => 'Пожалуйста, введите настоящий E-mail адрес.'],
            ['email', 'string', 'max' => 255, 'message' => 'Введите настоящий E-mail адрес.'],
            ['password', 'required', 'message' => 'Это поле не может быть пустым.'],
            ['password', 'string', 'min' => 6,  'message' => 'Длина пароля не менее 6 символов.'],
        ];
    }

    public function loginup()
    {
        if (!$this->validate()) {
            return null;
        }
        $user->email = $this->email;
        $user->validatePassword($this->password);
        
    }
    
}