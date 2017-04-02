<?php
namespace frontend\modules\home\models;

use yii\base\Model;
use common\models\User;

class SignupForm extends Model
{
    public $email;
    public $password;
    public $passwordRepeat;
    public $role;


    public function rules()
    {
        return [
            ['email', 'filter', 'filter' => 'trim'],
            ['email', 'required', 'message' => 'Это поле не может быть пустым.'],
            ['email', 'email', 'message' => 'Пожалуйста, введите настоящий E-mail адрес.'],
            ['email', 'string', 'max' => 255, 'message' => 'Введите настоящий E-mail адрес.'],
            ['email', 'unique', 'targetClass' => '\common\models\User', 'message' => 'Пользователь с таким E-mail уже зарегистрирован.'],

            ['password', 'required', 'message' => 'Это поле не может быть пустым.'],
            ['passwordRepeat', 'required',  'message' => 'Это поле не может быть пустым.'],
            ['password', 'string', 'min' => 6,  'message' => 'Длина пароля не меннее 6 символов.'],
        ];
    }

   
    public function signup()
    {
        if (!$this->validate()) {
            return null;
        }
        
        $user = new User();
        $user->email = $this->email;
        $user->setPassword($this->password);

        // var_dump($user);
        // var_dump($user->save());
        // exit();
        
        return $user->save() ? $user : null;
    }
}
