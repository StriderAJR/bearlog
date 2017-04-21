<div class="container">
	<div class="section white-section">
		<div class="profile-wrapper">
			<div class="row">
				<div class="col-sm-6 col-sm-push-6">
					<h2>Создать новый перевод</h2>
					<br>
					<a class="btn btn-success btn-md" href="/translation/creation">Создать новый перевод</a>
				</div>
				<div class="col-sm-6 col-sm-pull-6">
					<h2>Мои переводы</h2>
					
					<?php if (!count($model['translations'])): ?>
						<p>Пока что нет ни одного перевода:(</p>
					<?php endif; ?>
					<?php foreach ($model['translations'] as $key => $category): ?>

						<?php if ($key == 'books'): ?>
							<?php foreach ($category as $translation): ?>
								<div class="media">
								  <div class="media-left">
								    <img src="<?=$translation['cover_link']?>" class="media-object" style="width:60px">
								  </div>
								  <div class="media-body">
								    <h4 class="media-heading"><?=$translation['name']?></h4>
								    <p>
								    	<a href="/translation/creation/data?translationBookID=<?=$translation['book_id']?>">Просмотр</a>
								    </p>
								  </div>
								</div>
							<?php endforeach; ?>		
						<?php endif; ?>

					<?php endforeach; ?>
				</div>

			</div>
		</div>
	</div>
</div>