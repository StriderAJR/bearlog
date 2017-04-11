<?php
    use frontend\assets\MainAsset;
    use yii\helpers\Html;
    use common\widgets\Alert;

    MainAsset::register($this);
?>
<?php $this->beginPage() ?>
<!DOCTYPE html>
<html lang="<?= Yii::$app->language ?>">
<head>
        <meta charset="<?= Yii::$app->charset ?>">
        <meta content='width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0' name='viewport' />
        <?= Html::csrfMetaTags() ?>
        <title>Bearlog</title>
        <?php $this->head() ?>
        <link rel="shortcut icon" type="image/png" href="/favicon.png"/>
</head>
<body class="inside-page">
    <div class="navbar navbar-default navbar-fixed-top inside-nav">
      <div class="container">
        <div class="navbar-header">
          <a href="/" class="navbar-brand">
            <img src="/img/logo.png">
          </a>
          <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
        </div>

        <div class="navbar-collapse collapse" id="navbar-main">
          <ul class="nav navbar-nav visible-xs">
            <li>
              <a href="#">Преимущества</a>
            </li>
            <li>
              <a href="#">Портфолио</a>
            </li>
            <li>
              <a href="#">Как стать участником ?</a>
            </li>
            <li>
              <a href="#">Контакты</a>
            </li>
          </ul>

            <div class="logged-user-info navbar-right">
              <i class="fa fa-user-circle user-icon" aria-hidden="true"></i>
              <?= Yii::$app->user->identity->email ?>
              <a href="/?logout=true" class="btn btn-success btn-logout btn-md">Выйти</a>
            </div>

        </div>
        <div class="navbar-bottom hidden-xs">
         <ul class="nav navbar-nav">
            <li>
              <a href="#">Преимущества</a>
            </li>
            <li>
              <a href="#">Портфолио</a>
            </li>
            <li>
              <a href="#">Как стать участником?</a>
            </li>
            <li>
              <a href="#">Контакты</a>
            </li>
          </ul>
        </div>
      </div>

    </div>

    <?= $content ?>
    <?php $this->endBody() ?>
</body>
</html>
<?php $this->endPage() ?>